using System;
using System.Collections.Generic;
using System.Text;
///////////////////////////////////
//   JHUNELL BARCENAS            //
///////////////////////////////////
namespace GDC.PH.AIDE.BusinessLayer
{
	public class clsAssetsKeys
	{

		#region Data Members

        int _assetID;

		#endregion

        #region Constructor

        public clsAssetsKeys(int assetID)
        {
            _assetID = assetID;
        }



		#endregion

        #region Properties

        public int ASSET_ID
        {
            get { return _assetID; }
        }


		#endregion

	}
}
///////////////////////////////////
//   JHUNELL BARCENAS            //
///////////////////////////////////