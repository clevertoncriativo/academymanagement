using academymanagement.Application.Interfaces;
using academymanagement.Domain.Commons.Extensions;
using academymanagement.Domain.Entities;
using academymanagement.Domain.Interfaces.Repositories;
using academymanagement.Domain.Messages.Responses;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace academymanagement.Application.Apps
{
    public class UserGroupApp : IUserGroupApp
    {
        private readonly IUserGroupRepository _userGroupRepository;
        private readonly IUnitOfWork _wou;
        private readonly IValidator<UserGroup> _userGroupValidator;
        public ICollection<ResponseError> _responseErrors { get; set; }

        public UserGroupApp(IUserGroupRepository userGroupRepository, 
                            IUnitOfWork wou, 
                            IValidator<UserGroup> userGroupValidator)
        {
            this._userGroupRepository = userGroupRepository;
            this._userGroupValidator = userGroupValidator;
            this._wou = wou;
            this._responseErrors = new List<ResponseError>();
        }        

        public async Task<ResponseMessage<bool>> DeleteAsync(UserGroup userGroup)
        {
            try
            {                
                bool exist = await _userGroupRepository.ExistUserAssociate(userGroup.Id);

                if (exist)
                {
                    _responseErrors.Add(new ResponseError("Id", $"Não foi possível excluir o grupo de usuário Id: {userGroup.Id} porque ele esta associado a pelo menos um usuário."));

                    return new ResponseMessage<bool>() { Errors = _responseErrors };
                }

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

        public async Task<ResponseMessage<UserGroup>> FindByIdAsync(int id)
        {
            var userGroup = await _userGroupRepository.FindByIdAsync(id);

            return new ResponseMessage<UserGroup>(userGroup);
        }

        public async Task<ResponseMessage<UserGroup>> SaveAsync(UserGroup userGroup)
        {
            try
            {
                var result = await _userGroupValidator.ValidateAsync(userGroup);

                if (!result.IsValid)
                {
                    return new ResponseMessage<UserGroup>(){ Errors = result.AsReponseErrors() };
                }

                await _userGroupRepository.SaveAsync(userGroup);

                _wou.CommitAsync();

                return new ResponseMessage<UserGroup>(userGroup);
            }
            catch (Exception ex)
            {
                _wou.RollbackAsync();

                _responseErrors.Add(new ResponseError("An exception occurred in request:", ex?.Message));

                return new ResponseMessage<UserGroup>() { Errors = _responseErrors };
            }
        }
    }
}
