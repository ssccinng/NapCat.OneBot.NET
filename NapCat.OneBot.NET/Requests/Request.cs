using NapCat.OneBot.NET.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NapCat.OneBot.NET.Requests
{


    public class Request(string action)
    {
        public readonly string Action = action;
    }

    public class SendPrivateMsg() : Request("send_private_msg")
    {
        [JsonPropertyName("user_id")]
        public int UserId { get; set; }
        [JsonPropertyName("message")]
        public object[] Message { get; set; } = [];
        [JsonPropertyName("auto_escape")]
        public bool AutoEscape { get; set; }
    }

    public record SendprivateMsgResponse(string message_id);
    public class SendGroupMsg() : Request("send_group_msg")
    {
        [JsonPropertyName("group_id")]
        public long GroupId { get; set; }

        [JsonPropertyName("message")]
        public object[] Message { get; set; } = [];


        [JsonPropertyName("auto_escape")]
        public bool AutoEscape { get; set; }
    }

    public record SendGroupMsgResponse(long message_id);

    public class SendMsg() : Request("send_msg")
    {
        [JsonPropertyName("message_type")]
        public string MessageType { get; set; } = string.Empty;

        [JsonPropertyName("user_id")]
        public long UserId { get; set; }

        [JsonPropertyName("group_id")]
        public long GroupId { get; set; }

        [JsonPropertyName("message")]
        public object[] Message { get; set; } = [];


        [JsonPropertyName("auto_escape")]
        public bool AutoEscape { get; set; }
    }

    public record SendMsgResponse(long message_id);

    public class DeleteMsg() : Request("delete_msg")
    {
        [JsonPropertyName("message_id")]
        public long MessageId { get; set; }
    }

    public class GetMsg() : Request("get_msg")
    {
        [JsonPropertyName("message_id")]
        public long MessageId { get; set; }
    }

    public record GetMsgResponse(long time, string message_type, long message_id, long real_id, object sender, string message);

    public class GetForwardMsg() : Request("get_forward_msg")
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;
    }

    public record GetForwardMsgResponse(string message);

    public class SendLike() : Request("send_like")
    {
        [JsonPropertyName("user_id")]
        public long UserId { get; set; }

        [JsonPropertyName("times")]
        public int Times { get; set; } = 1;
    }

    public class SetGroupKick() : Request("set_group_kick")
    {
        [JsonPropertyName("group_id")]
        public long GroupId { get; set; }

        [JsonPropertyName("user_id")]
        public long UserId { get; set; }

        [JsonPropertyName("reject_add_request")]
        public bool RejectAddRequest { get; set; }
    }

    public class SetGroupBan() : Request("set_group_ban")
    {
        [JsonPropertyName("group_id")]
        public long GroupId { get; set; }

        [JsonPropertyName("user_id")]
        public long UserId { get; set; }

        [JsonPropertyName("duration")]
        public long Duration { get; set; } = 30 * 60;
    }

    public class SetGroupAnonymousBan() : Request("set_group_anonymous_ban")
    {
        [JsonPropertyName("group_id")]
        public long GroupId { get; set; }

        [JsonPropertyName("anonymous")]
        public object Anonymous { get; set; }

        [JsonPropertyName("anonymous_flag")]
        public string AnonymousFlag { get; set; } = string.Empty;

        [JsonPropertyName("duration")]
        public long Duration { get; set; } = 30 * 60;
    }

    public class SetGroupWholeBan() : Request("set_group_whole_ban")
    {
        [JsonPropertyName("group_id")]
        public long GroupId { get; set; }

        [JsonPropertyName("enable")]
        public bool Enable { get; set; } = true;
    }

    public class SetGroupAdmin() : Request("set_group_admin")
    {
        [JsonPropertyName("group_id")]
        public long GroupId { get; set; }

        [JsonPropertyName("user_id")]
        public long UserId { get; set; }

        [JsonPropertyName("enable")]
        public bool Enable { get; set; } = true;
    }

    public class SetGroupAnonymous() : Request("set_group_anonymous")
    {
        [JsonPropertyName("group_id")]
        public long GroupId { get; set; }

        [JsonPropertyName("enable")]
        public bool Enable { get; set; } = true;
    }

    public class SetGroupCard() : Request("set_group_card")
    {
        [JsonPropertyName("group_id")]
        public long GroupId { get; set; }

        [JsonPropertyName("user_id")]
        public long UserId { get; set; }

        [JsonPropertyName("card")]
        public string Card { get; set; } = string.Empty;
    }

    public class SetGroupName() : Request("set_group_name")
    {
        [JsonPropertyName("group_id")]
        public long GroupId { get; set; }

        [JsonPropertyName("group_name")]
        public string GroupName { get; set; } = string.Empty;
    }

    public class SetGroupLeave() : Request("set_group_leave")
    {
        [JsonPropertyName("group_id")]
        public long GroupId { get; set; }

        [JsonPropertyName("is_dismiss")]
        public bool IsDismiss { get; set; }
    }

    public class SetGroupSpecialTitle() : Request("set_group_special_title")
    {
        [JsonPropertyName("group_id")]
        public long GroupId { get; set; }

        [JsonPropertyName("user_id")]
        public long UserId { get; set; }

        [JsonPropertyName("special_title")]
        public string SpecialTitle { get; set; } = string.Empty;

        [JsonPropertyName("duration")]
        public long Duration { get; set; } = -1;
    }

    public class SetFriendAddRequest() : Request("set_friend_add_request")
    {
        [JsonPropertyName("flag")]
        public string Flag { get; set; } = string.Empty;

        [JsonPropertyName("approve")]
        public bool Approve { get; set; } = true;

        [JsonPropertyName("remark")]
        public string Remark { get; set; } = string.Empty;
    }

    public class SetGroupAddRequest() : Request("set_group_add_request")
    {
        [JsonPropertyName("flag")]
        public string Flag { get; set; } = string.Empty;

        [JsonPropertyName("sub_type")]
        public string SubType { get; set; } = string.Empty;

        [JsonPropertyName("approve")]
        public bool Approve { get; set; } = true;

        [JsonPropertyName("reason")]
        public string Reason { get; set; } = string.Empty;
    }

    public class GetLoginInfo() : Request("get_login_info")
    {
    }

    public record GetLoginInfoResponse(long user_id, string nickname);

    public class GetStrangerInfo() : Request("get_stranger_info")
    {
        [JsonPropertyName("user_id")]
        public long UserId { get; set; }

        [JsonPropertyName("no_cache")]
        public bool NoCache { get; set; }
    }

    public record GetStrangerInfoResponse(long user_id, string nickname, string sex, int age);

    public class GetFriendList() : Request("get_friend_list")
    {
    }

    public record FriendInfo(long user_id, string nickname, string remark);

    public class GetGroupInfo() : Request("get_group_info")
    {
        [JsonPropertyName("group_id")]
        public long GroupId { get; set; }

        [JsonPropertyName("no_cache")]
        public bool NoCache { get; set; }
    }

    public record GetGroupInfoResponse(long group_id, string group_name, int member_count, int max_member_count);

    public class GetGroupList() : Request("get_group_list")
    {
    }

    public record GroupInfo(long group_id, string group_name, int member_count, int max_member_count);

    public class GetGroupMemberInfo() : Request("get_group_member_info")
    {
        [JsonPropertyName("group_id")]
        public long GroupId { get; set; }

        [JsonPropertyName("user_id")]
        public long UserId { get; set; }

        [JsonPropertyName("no_cache")]
        public bool NoCache { get; set; }
    }

    public record GetGroupMemberInfoResponse(long group_id, long user_id, string nickname, string card, string sex, int age, string area, int join_time, int last_sent_time, string level, string role, bool unfriendly, string title, int title_expire_time, bool card_changeable);

    public class GetGroupMemberList() : Request("get_group_member_list")
    {
        [JsonPropertyName("group_id")]
        public long GroupId { get; set; }
    }

    public record GroupMemberInfo(long group_id, long user_id, string nickname, string card, string sex, int age, string area, int join_time, int last_sent_time, string level, string role, bool unfriendly, string title, int title_expire_time, bool card_changeable);

    public class GetGroupHonorInfo() : Request("get_group_honor_info")
    {
        [JsonPropertyName("group_id")]
        public long GroupId { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;
    }

    public record GetGroupHonorInfoResponse(long group_id, object current_talkative, object[] talkative_list, object[] performer_list, object[] legend_list, object[] strong_newbie_list, object[] emotion_list);

    public class GetCookies() : Request("get_cookies")
    {
        [JsonPropertyName("domain")]
        public string Domain { get; set; } = string.Empty;
    }

    public record GetCookiesResponse(string cookies);

    public class GetCsrfToken() : Request("get_csrf_token")
    {
    }

    public record GetCsrfTokenResponse(int token);

    public class GetCredentials() : Request("get_credentials")
    {
        [JsonPropertyName("domain")]
        public string Domain { get; set; } = string.Empty;
    }

    public record GetCredentialsResponse(string cookies, int csrf_token);

    public class GetRecord() : Request("get_record")
    {
        [JsonPropertyName("file")]
        public string File { get; set; } = string.Empty;

        [JsonPropertyName("out_format")]
        public string OutFormat { get; set; } = string.Empty;
    }

    public record GetRecordResponse(string file);

    public class GetImage() : Request("get_image")
    {
        [JsonPropertyName("file")]
        public string File { get; set; } = string.Empty;
    }

    public record GetImageResponse(string file);

    public class CanSendImage() : Request("can_send_image")
    {
    }

    public record CanSendImageResponse(bool yes);

    public class CanSendRecord() : Request("can_send_record")
    {
    }

    public record CanSendRecordResponse(bool yes);

    public class GetStatus() : Request("get_status")
    {
    }

    public record GetStatusResponse(bool online, bool good);

    public class GetVersionInfo() : Request("get_version_info")
    {
    }


    public class SetRestart() : Request("set_restart")
    {
        [JsonPropertyName("delay")]
        public int Delay { get; set; } = 0;
    }

    public class CleanCache() : Request("clean_cache")
    {
    }
}
