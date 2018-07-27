using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Common.Logic.Log4net
{
    public interface ILogger
    {
        #region Methods
        void Debug(Object message);
        void Error(Object message);
        #endregion

    }
}
