using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tillsammans.Storage;

namespace tillsammans.App
{
    public static class Maps
    {
        public static GroupDto ToDto(this Group group)
        {
            return new GroupDto()
            {
                id = group.id,
                name = group.name,
                members = group.members.Select(m => m.ToDto()).ToList()
            };
        }

        public static ProfileDto ToDto(this Profile profile)
        {
            return new ProfileDto()
            {
                id = profile.id,
                name = profile.name,
                memberships = profile.memberships.Select(m => m.ToDto()).ToList()
            };
        }

        public static MembershipDto ToDto(this Membership membership)
        {
            return new MembershipDto()
            {
                GroupId = membership.groupId,
                GroupName = membership.groupName,
                NickName = membership.nickName
            };
        }


        public static GroupEventDto ToDto(this GroupEvent groupEvent)
        {
            return new GroupEventDto()
            {
                id = groupEvent.id,
                groupId = groupEvent.groupId,
                collectionKey = groupEvent.collectionKey,
                key = groupEvent.key,
                participants = groupEvent.participants.Select(p => p.ToDto()).ToList()
            };
        }

        public static ParticipantDto ToDto(this Participant participant)
        {
            return new ParticipantDto()
            {
                UserId = participant.userId,
                StatusId = participant.statusId
            };
        }

        public static GroupMemberDto ToDto(this GroupMember groupMember)
        {
            return new GroupMemberDto()
            {
                userId = groupMember.userId,
                nickName = groupMember.nickName
            };
        }

        public static GroupEventCollectionDto ToDto(this IEnumerable<GroupEvent> groupEvents, string groupId, string collectionKey)
        {
            return new GroupEventCollectionDto()
            {
                groupId = groupId,
                collectionKey = collectionKey,
                events = new List<GroupEventDto>(groupEvents.Select(ge => ge.ToDto()))
            };
        }

    }
}
