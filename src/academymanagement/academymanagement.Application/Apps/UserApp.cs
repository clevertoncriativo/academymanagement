using academymanagement.Application.Interfaces;
using academymanagement.Domain.Commons.Extensions;
using academymanagement.Domain.Commons.Filters;
using academymanagement.Domain.Entities;
using academymanagement.Domain.Interfaces.Repositories;
using academymanagement.Domain.Interfaces.Services;
using academymanagement.Domain.Messages;
using academymanagement.Domain.Messages.Responses;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
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
        private readonly IJwtService _jwt;
        public  ICollection<ResponseError> _responseErrors { get; set; }

        public UserApp(IUserRepository userepository, 
                       IUnitOfWork wou, 
                       IValidator<User> userValidator,
                       IJwtService jwt)
        {
            this._userRepository = userepository;
            this._userValidator = userValidator;
            this._wou = wou;
            this._jwt = jwt;
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

                var passwordHasher = new PasswordHasher<User>();
                user.Password = passwordHasher.HashPassword(user, user.Password);
                
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

        public async Task<ResponseMessage<UserAutenticatedMessage>> AutenticateAsync(User user)
        {
            var _userSearch = await _userRepository.FindUser(user.Email);

            if (_userSearch == null)
            {
                return null;
            }

            var isValid = await ValidateUpdateHashAsync(user, _userSearch.Password);

            if (isValid)
            {
                var userAutenticatedMessage = new UserAutenticatedMessage()
                {
                    Email = _userSearch.Email,
                    Roles = _userSearch.Roles
                };

                userAutenticatedMessage.Token = _jwt.GenerateToken(_userSearch);
                
                return new ResponseMessage<UserAutenticatedMessage>(userAutenticatedMessage);
            }

            return null;

        }

        private async Task<bool> ValidateUpdateHashAsync(User user, string hash)
        {
            var passwordHasher = new PasswordHasher<User>();
            var status = passwordHasher.VerifyHashedPassword(user, hash, user.Password);
            
            switch (status)
            {
                case PasswordVerificationResult.Failed:
                    return false;

                case PasswordVerificationResult.Success:
                    return true;

                case PasswordVerificationResult.SuccessRehashNeeded:
                    await SaveAsync(user);
                    return true;

                default:
                    throw new InvalidOperationException();
            }
        }
    }

}
