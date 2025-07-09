namespace Softwash.Infrastructure.Common.GenericResponse;

public static class Output
{
    public static OutputDTO<T> Handler<T>(int responseCode, T? dto, string? name = "Record", int totalCount = 0)
    {
        var obj = new OutputDTO<T>()
        {
            Data = dto,
            TotalCounts = totalCount
        };

        switch (responseCode)
        {
            case (int)ResponseType.GET:
                obj.HttpStatusCode = ResponseCode.OK;
                obj.Message = string.Format(ResponseMessage.GET, name);
                break;

            case (int)ResponseType.GET_ALL:
                obj.Succeeded = true;
                obj.HttpStatusCode = ResponseCode.OK;
                obj.Message = string.Format(ResponseMessage.GET_ALL, name);
                break;

            case (int)ResponseType.RESTORED:
                obj.Succeeded = true;
                obj.HttpStatusCode = ResponseCode.OK;
                obj.Message = string.Format(ResponseMessage.RESTORED, name);
                break;

            case (int)ResponseType.CREATE:
                obj.Succeeded = true;
                obj.HttpStatusCode = ResponseCode.OK;
                obj.Message = string.Format(ResponseMessage.CREATE, name);
                break;

            case (int)ResponseType.UPDATE:
                obj.HttpStatusCode = ResponseCode.OK;
                obj.Message = string.Format(ResponseMessage.UPDATE, name);
                break;


            case (int)ResponseType.INVITATION_SENT:
                obj.HttpStatusCode = ResponseCode.OK;
                obj.Message = ResponseMessage.INVITATION_SENT;
                obj.Succeeded = true;
                break;

            case (int)ResponseType.IS_BLOCKED:
                obj.HttpStatusCode = ResponseCode.OK;
                obj.Message = ResponseMessage.IS_BLOCKED;
                obj.Succeeded = true;
                break;
            case (int)ResponseType.IS_UNBLOCKED:
                obj.HttpStatusCode = ResponseCode.OK;
                obj.Message = ResponseMessage.IS_UNBLOCKED;
                obj.Succeeded = true;
                break;

            case (int)ResponseType.REQUEST_STATUS:
                obj.HttpStatusCode = ResponseCode.OK;
                obj.Message = string.Format(ResponseMessage.REQUEST_STATUS, name);
                obj.Succeeded = true;
                break;

            case (int)ResponseType.DROPDOWN:
                obj.HttpStatusCode = ResponseCode.OK;
                obj.Message = string.Format(ResponseMessage.DROPDOWN, name);
                break;

            case (int)ResponseType.UPLOADED:
                obj.HttpStatusCode = ResponseCode.OK;
                obj.Message = string.Format(ResponseMessage.UPLOADED, name);
                break;

            case (int)ResponseType.CHAT_REQUEST_STATUS:
                obj.HttpStatusCode = ResponseCode.OK;
                obj.Message = string.Format(ResponseMessage.CHAT_REQUEST_STATUS, name);
                obj.Succeeded = true;
                break;

            case (int)ResponseType.DELETE:
                obj.Succeeded = true;
                obj.HttpStatusCode = ResponseCode.OK;
                obj.Message = string.Format(ResponseMessage.DELETE, name);
                break;

            case (int)ResponseType.CUSTOM_TRUE:
                obj.HttpStatusCode = ResponseCode.BAD;
                obj.Message = string.Format(ResponseMessage.CUSTOM_TRUE, name);
                obj.Succeeded = false;
                break;

            case (int)ResponseType.INVALID_DELETE:
                obj.Succeeded = false;
                obj.HttpStatusCode = ResponseCode.BAD;
                obj.Message = string.Format(ResponseMessage.INVALID_DELETE, name);
                break;

            case (int)ResponseType.INVALID_REQUEST:
                obj.Succeeded = false;
                obj.HttpStatusCode = ResponseCode.BAD;
                obj.Message = ResponseMessage.INVALID_REQUEST;
                break;

            case (int)ResponseType.INCOMPLETE_PROFILE:
                obj.Succeeded = false;
                obj.HttpStatusCode = ResponseCode.BAD;
                obj.Message = ResponseMessage.INCOMPLETE_PROFILE;
                break;

            case (int)ResponseType.ALREADY_EXIST:
                obj.Succeeded = false;
                obj.HttpStatusCode = ResponseCode.BAD;
                obj.Message = string.Format(ResponseMessage.ALREADY_EXIST, name);
                break;

            case (int)ResponseType.CHECKED_IN:
                obj.Succeeded = false;
                obj.HttpStatusCode = ResponseCode.BAD;
                obj.Message = ResponseMessage.CHECKED_IN;
                break;

            case (int)ResponseType.ALREADY_IN_USE:
                obj.Succeeded = false;
                obj.HttpStatusCode = ResponseCode.BAD;
                obj.Message = string.Format(ResponseMessage.ALREADY_IN_USE, name);
                break;

            case (int)ResponseType.OUTSIDE_RANGE_ERROR:
                obj.Succeeded = false;
                obj.HttpStatusCode = ResponseCode.BAD;
                obj.Message = ResponseMessage.OUTSIDE_RANGE_ERROR;
                break;

            case (int)ResponseType.NOT_VERIFIED:
                obj.Succeeded = false;
                obj.HttpStatusCode = ResponseCode.BAD;
                obj.Message = ResponseMessage.NOT_VERIFIED;
                break;


            case (int)ResponseType.CUSTOM_ERROR:
                obj.Succeeded = false;
                obj.HttpStatusCode = ResponseCode.BAD;
                obj.Message = string.Format(ResponseMessage.CUSTOM_ERROR, name);
                break;

            case (int)ResponseType.LIMIT_EXCEED:
                obj.Succeeded = false;
                obj.HttpStatusCode = ResponseCode.BAD;
                obj.Message = string.Format(ResponseMessage.LIMIT_EXCEED, name);
                break;

            case (int)ResponseType.ALREADY_ACOOUNT_DELETED:
                obj.Succeeded = false;
                obj.HttpStatusCode = ResponseCode.BAD;
                obj.Message = string.Format(ResponseMessage.ALREADY_ACOOUNT_DELETED, name);
                break;

            case (int)ResponseType.ALREADY_BLOCKED:
                obj.Succeeded = false;
                obj.HttpStatusCode = ResponseCode.BAD;
                obj.Message = string.Format(ResponseMessage.ALREADY_BLOCKED, name);
                break;

            case (int)ResponseType.ALREADY_UNBLOCKED:
                obj.Succeeded = false;
                obj.HttpStatusCode = ResponseCode.BAD;
                obj.Message = string.Format(ResponseMessage.ALREADY_UNBLOCKED, name);
                break;

            case (int)ResponseType.ALREADY_DELETED:
                obj.Succeeded = false;
                obj.HttpStatusCode = ResponseCode.BAD;
                obj.Message = string.Format(ResponseMessage.ALREADY_DELETED, name);
                break;

            case (int)ResponseType.ALREADY_INACTIVE:
                obj.Succeeded = false;
                obj.HttpStatusCode = ResponseCode.BAD;
                obj.Message = string.Format(ResponseMessage.ALREADY_INACTIVE, name);
                break;

            case (int)ResponseType.ALREADY_ACTIVE:
                obj.Succeeded = false;
                obj.HttpStatusCode = ResponseCode.BAD;
                obj.Message = string.Format(ResponseMessage.ALREADY_ACTIVE, name);
                break;


            case (int)ResponseType.EXIST:
                obj.Succeeded = false;
                obj.HttpStatusCode = ResponseCode.BAD;
                obj.Message = string.Format(ResponseMessage.EXIST, name);
                break;

            case (int)ResponseType.NOT_EXIST:
                obj.Succeeded = true;
                obj.HttpStatusCode = ResponseCode.BAD;
                obj.Message = string.Format(ResponseMessage.NOT_EXIST, name);
                break;

            case (int)ResponseType.ENTITY_NOT_EXIST:
                obj.Succeeded = true;
                obj.HttpStatusCode = ResponseCode.OK;
                obj.Message = string.Format(ResponseMessage.ENTITY_NOT_EXIST, name);
                break;

            case (int)ResponseType.INVALID_CREDENTIALS:
                obj.Succeeded = false;
                obj.HttpStatusCode = ResponseCode.BAD;
                obj.Message = ResponseMessage.INVALID_CREDENTIALS;
                break;

            case (int)ResponseType.SUCCESSFULLY_LOGIN:
                obj.Succeeded = true;
                obj.HttpStatusCode = ResponseCode.OK;
                obj.Message = ResponseMessage.SUCCESSFULLY_LOGIN;
                break;

            case (int)ResponseType.SUCCESSFULLY_REGISTER:
                obj.HttpStatusCode = ResponseCode.OK;
                obj.Message = ResponseMessage.SUCCESSFULLY_REGISTER;
                break;


            case (int)ResponseType.INVALID_ROLE:
                obj.Succeeded = false;
                obj.HttpStatusCode = ResponseCode.BAD;
                obj.Message = ResponseMessage.INVALID_ROLE;
                break;

            case (int)ResponseType.SEND_OTP:
                obj.Succeeded = true;
                obj.HttpStatusCode = ResponseCode.OK;
                obj.Message = ResponseMessage.SEND_OTP;
                break;

            case (int)ResponseType.INVALID_OTP:
                obj.Succeeded = false;
                obj.HttpStatusCode = ResponseCode.BAD;
                obj.Message = ResponseMessage.INVALID_OTP;
                break;

            case (int)ResponseType.OTP_EXPIRE:
                obj.Succeeded = false;
                obj.HttpStatusCode = ResponseCode.BAD;
                obj.Message = ResponseMessage.OTP_EXPIRE;
                break;

            case (int)ResponseType.RESEND_OTP:
                obj.Succeeded = true;
                obj.HttpStatusCode = ResponseCode.OK;
                obj.Message = ResponseMessage.RESEND_OTP;
                break;

            case (int)ResponseType.CONFIRM_OLD_PASWORD:
                obj.Succeeded = true;
                obj.HttpStatusCode = ResponseCode.OK;
                obj.Message = ResponseMessage.CONFIRM_OLD_PASWORD;
                break;

            case (int)ResponseType.CONFIRM_OLD_PASWORD_NOT_MATCH:
                obj.Succeeded = false;
                obj.HttpStatusCode = ResponseCode.BAD;
                obj.Message = ResponseMessage.CONFIRM_OLD_PASWORD_NOT_MATCH;
                break;

            case (int)ResponseType.CHANGE_PASSWORD:
                obj.Succeeded = true;
                obj.HttpStatusCode = ResponseCode.OK;
                obj.Message = ResponseMessage.CHANGE_PASSWORD;
                break;


            case (int)ResponseType.CONFIRM_OTP:
                obj.Succeeded = true;
                obj.HttpStatusCode = ResponseCode.OK;
                obj.Message = ResponseMessage.CONFIRM_OTP;
                break;

            case (int)ResponseType.INVALID_PASSWORD:
                obj.Succeeded = false;
                obj.HttpStatusCode = ResponseCode.BAD;
                obj.Message = ResponseMessage.INVALID_PASSWORD;
                break;

            case (int)ResponseType.MESSAGE_READ:
                obj.Succeeded = true;
                obj.HttpStatusCode = ResponseCode.OK;
                obj.Message = ResponseMessage.MESSAGE_READ;
                break;

            case (int)ResponseType.MESSAGE_SEND:
                obj.Succeeded = true;
                obj.HttpStatusCode = ResponseCode.OK;
                obj.Message = ResponseMessage.MESSAGE_SEND;
                break;

            case (int)ResponseType.MESSAGE_UPDATED:
                obj.Succeeded = true;
                obj.HttpStatusCode = ResponseCode.OK;
                obj.Message = ResponseMessage.MESSAGE_UPDATED;
                break;

            case (int)ResponseType.CUSTOM_RESPONSE:
                obj.Succeeded = true;
                obj.HttpStatusCode = ResponseCode.OK;
                obj.Message = string.Format(ResponseMessage.CUSTOM_RESPONSE, name);
                break;

            case (int)ResponseType.ACTIVATED:
                obj.Succeeded = true;
                obj.HttpStatusCode = (int)ResponseCode.OK;
                obj.Message = string.Format(ResponseMessage.ACTIVATED, name);
                break;

            case (int)ResponseType.DEACTIVATED:
                obj.Succeeded = true;
                obj.HttpStatusCode = (int)ResponseCode.OK;
                obj.Message = string.Format(ResponseMessage.DEACTIVATED, name);
                break;

        }

        return obj;
    }
}
