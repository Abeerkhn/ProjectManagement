namespace Softwash.Infrastructure.Common.GenericResponse
{
    public static class ResponseCode
    {
        public const int OK = 200;
        public const int BAD = 400;
    }
    public static class ResponseMessage
    {
        public const string ACTIVATED = "{0} is activated successfully";
        public const string GET = "{0} gets successfully.";
        public const string GET_ALL = "{0}s get successfully.";
        public const string CREATE = "{0} is created successfully.";
        public const string UPDATE = "{0} is updated successfully.";
        public const string DELETE = "{0} is deleted successfully.";
        public const string DEACTIVATED = "{0} is de-activated successfully.";
        public const string ALREADY_INACTIVE = "{0} is already Inactive.";
        public const string ALREADY_ACTIVE = "{0} is already active.";
        public const string ALREADY_DELETED = "{0} is already deleted.";
        public const string EXIST = "{0} already exist.";
        public const string NOT_EXIST = "{0} does not exist.";
        public const string ENTITY_NOT_EXIST = "User does not exist.";
        public const string BAD_REQUEST = "The server was unable to process the request.";
        public const string INVALID_CREDENTIALS = "Invalid credentials.";
        public const string SUCCESSFULLY_LOGIN = "You are successfully login.";
        public const string SUCCESSFULLY_REGISTER = "User is successfully registered.";
        public const string INVALID_ROLE = "Invalid role.";
        public const string SEND_OTP = "OTP has been send to your number.";
        public const string INVALID_OTP = "Invalid OTP.";
        public const string OTP_EXPIRE = "OTP has been expired.";
        public const string CONFIRM_OTP = "OTP has been confirmed.";
        public const string RESEND_OTP = "OTP has been resend.";
        public const string CONFIRM_OLD_PASWORD = "Old password has been confirmed successfully.";
        public const string CONFIRM_OLD_PASWORD_NOT_MATCH = "Old password does not match.";
        public const string CHANGE_PASSWORD = "Password has been changed successfully.";
        public const string INVALID_PASSWORD = "Invalid password";
        public const string MESSAGE_READ = "Message Read";
        public const string MESSAGE_SEND = "Message has been Send";
        public const string MESSAGE_UPDATED = "Message has been Updated";
        public const string INVALID_REQUEST = "INVALID REQUEST";
        public const string CUSTOM_RESPONSE = "{0}";
        public const string INVALID_DELETE = "Delete Operation Can not be Proceeded.";
        public const string ALREADY_ACOOUNT_DELETED = "Chart of Account Already Exist.";
        public const string LIMIT_EXCEED = "Maximum Limit Reached";
        public const string UPLOADED = "File is Uploaded";
        public const string OUTSIDE_RANGE_ERROR = "The provided days do not fall within the specified range";
        public const string ALREADY_EXIST = "{0} Already Exist!";
        public const string DROPDOWN = "Dropdowns of {0}";
        public const string NOT_VERIFIED = "user is not Verified";
        public const string REQUEST_STATUS = "Friend Request is {0}";
        public const string CUSTOM_TRUE = "{0}";
        public const string IS_BLOCKED = "User is Blocked Successfully";
        public const string IS_UNBLOCKED = "User is Unblocked Successfully";
        public const string ALREADY_BLOCKED = "{0} Already Blocked!";
        public const string ALREADY_UNBLOCKED = "{0} Already UnBlocked!";
        public const string CHAT_REQUEST_STATUS = "Chat Request is {0}";
        public const string ALREADY_IN_USE = "{0} is already in use";
        public const string INVITATION_SENT = "Invitation Sent Successfully!";
        public const string RESTORED = "User Is Restored Successfully";
        public const string CHECKED_IN = "User Is already CheckedIn!";
        public const string INCOMPLETE_PROFILE = "User Profile is InComplete!";
        public const string CUSTOM_ERROR = "{0}";
        
    }

    public enum ResponseType
    {
        GET,
        GET_ALL,
        RESTORED,
        ACTIVATED,
        DEACTIVATED,
        CREATE,
        UPDATE,
        DELETE,
        EXIST,
        NOT_EXIST,
        ENTITY_NOT_EXIST,
        INVALID_CREDENTIALS,
        INVALID_PASSWORD,
        SUCCESSFULLY_LOGIN,
        SUCCESSFULLY_REGISTER,
        INVALID_ROLE,
        SEND_OTP,
        INVALID_OTP,
        OTP_EXPIRE,
        RESEND_OTP,
        CONFIRM_OLD_PASWORD,
        CONFIRM_OLD_PASWORD_NOT_MATCH,
        CHANGE_PASSWORD,
        CONFIRM_OTP,
        MESSAGE_READ,
        MESSAGE_SEND,
        MESSAGE_UPDATED,
        CUSTOM_RESPONSE,
        ALREADY_DELETED,
        ALREADY_INACTIVE,
        ALREADY_ACTIVE,
        ALREADY_EXIST,
        INVALID_DELETE,
        ALREADY_ACOOUNT_DELETED,
        LIMIT_EXCEED,
        UPLOADED,
        OUTSIDE_RANGE_ERROR,
        DROPDOWN,
        REQUEST_STATUS,
        NOT_VERIFIED,
        CUSTOM_TRUE,
        IS_BLOCKED,
        IS_UNBLOCKED,
        ALREADY_BLOCKED,
        ALREADY_UNBLOCKED,
        CHAT_REQUEST_STATUS,
        ALREADY_IN_USE,
        INVITATION_SENT,
        CHECKED_IN,
        INVALID_REQUEST,
        INCOMPLETE_PROFILE,
        CUSTOM_ERROR
    }
}
