using academymanagement.Application.Interfaces;
using academymanagement.Domain.Commons.Extensions;
using academymanagement.Domain.Commons.Filters;
using academymanagement.Domain.Entities;
using academymanagement.Domain.Interfaces.Repositories;
using academymanagement.Domain.Messages.Responses;
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
        public  ICollection<ResponseError> _responseErrors { get; set; }

        public UserApp(IUserRepository userepository, 
                       IUnitOfWork wou, 
                       IValidator<User> userValidator)
        {
            this._userRepository = userepository;
            this._userValidator = userValidator;
            this._wou = wou;
            this._responseErrors = new List<ResponseError>();
        }

        public async Task<ResponseMessage<bool>> DeleteAsync(User user)
        {
            try
            {
                user.IsEnabled = false;

                var result = await _userRepository.SaveAsync(user);

                _wou.CommitAsync();

                return new ResponseMessage<bool>() { Succeeded = true };
            }
            catch (Exception ex)
            {
                _wou.RollbackAsync();

                _responseErrors.Add(new ResponseError("An exception occurred in request:", ex?.Message));

                return new ResponseMessage<bool>() { Errors = _responseErrors };
            }
        }

        public async Task<ResponseMessage<User>> FindByIdAsync(int id)
        {
            var user = await _userRepository.FindByIdAsync(id);

            return new ResponseMessage<User>(user);
        }

        public async Task<ResponseMessage<User>> SaveAsync(User user)
        {
            try
            {
                var result = await _userValidator.ValidateAsync(user);

                if (!result.IsValid)
                {
                    return new ResponseMessage<User>() { Errors = result.AsReponseErrors() };
                }

                await _userRepository.SaveAsync(user);

                _wou.CommitAsync();

                return new ResponseMessage<User>(user);
            }
            catch (Exception ex)
            {
                _wou.RollbackAsync();

                _responseErrors.Add(new ResponseError("An exception occurred in request:", ex?.Message));

                return new ResponseMessage<User>() { Errors = _responseErrors } ;
            }
        }

        public async Task<ResponseMessage<IEnumerable<User>>> FindAsync(PaginationFilter filter)
        {
            var response = await _userRepository.FindAsync(filter);

            return new ResponseMessage<IEnumerable<User>>(response);
        }
    }
}
