using academymanagement.Application.Interfaces;
using academymanagement.Domain.Commons.Extensions;
using academymanagement.Domain.Entities;
using academymanagement.Domain.Interfaces.Repositories;
using academymanagement.Domain.Messages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace academymanagement.Application.Apps
{
    public class UserApp : IUserApp
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _wou;
        private readonly IValidator<User> _userValidator;

        public UserApp(IUserRepository userepository, IUnitOfWork wou, IValidator<User> userValidator)
        {
            this._userRepository = userepository;
            this._userValidator = userValidator;
            this._wou = wou;
        }

        public async Task<ResponseMessage<bool>> DeleteAsync(User user)
        {
            try
            {
                user.IsEnabled = false;

                var result = await _userRepository.SaveAsync(user);

                _wou.CommitAsync();

                return ResponseMessage<bool>.FromResult(true);
            }
            catch (Exception ex)
            {
                _wou.RollbackAsync();

                var _errors = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("An exception occurred in request:", ex?.Message)
                };

                return ResponseMessage<bool>.FromInvalidResult(_errors);
            }
        }

        public async Task<ResponseMessage<User>> FindByIdAsync(int id)
        {
            var user = await _userRepository.FindByIdAsync(id);

            return ResponseMessage<User>.FromResult(user);
        }

        public async Task<ResponseMessage<User>> SaveAsync(User user)
        {
            try
            {
                var result = await _userValidator.ValidateAsync(user);

                if (!result.IsValid)
                {
                    return ResponseMessage<User>.FromInvalidResult(result.AsErrorProperties());
                }

                await _userRepository.SaveAsync(user);

                _wou.CommitAsync();

                return ResponseMessage<User>.FromResult(user);
            }
            catch (Exception ex)
            {
                _wou.RollbackAsync();

                var _errors = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("An exception occurred in request:", ex?.Message)
                };

                return ResponseMessage<User>.FromInvalidResult(_errors);
            }
        }
    }
}
