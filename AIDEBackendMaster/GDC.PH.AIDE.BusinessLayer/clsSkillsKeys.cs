using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// By Jhunell G. Barcenas
/// </summary>
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsSkillsKeys
    {
        #region Data Members

        int _EMP_ID;
        

        #endregion

        #region Constructor

        public clsSkillsKeys(int EMP_ID)
        {
            _EMP_ID = EMP_ID;
        }

        #endregion

        #region Properties

        public int EMP_ID
        {
            get { return _EMP_ID; }
        }

        #endregion
    }

    public class clsSkillsIDKeys
    {
        int _SKILL_ID;

        public clsSkillsIDKeys(int SKILL_ID)
        {
            _SKILL_ID = SKILL_ID;
        }

        public int SKILL_ID
        {
            get { return _SKILL_ID; }
        }
    }
}
