﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JotAThought.Domain.Contracts
{
    public interface IFormsAuthentication
    {
        void SignIn(string username, bool createPersistentCookie, IEnumerable<string> roles);
        void SignOut();
    }
}
