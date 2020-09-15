using System;

namespace tillsammans.Auth
{
    public class SessionDto
    {
        public string UserId { get; set; }
        public long Expires { get; set; }
        public string Token { get; set; }
    }
  }
