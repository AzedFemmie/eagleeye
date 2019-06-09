using System;
using System.Collections.Generic;
using System.Text;
using NPoco;

namespace EagleEye.Core.Interfaces
{
    public interface IDbFactory
    {
        IDatabase GetConnection();
    }
}
