﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Common.DataContracts;
using Common.Interfaces;
using Gobbi.CoreServices.Caching.CacheManagers;
using Gobbi.CoreServices.Caching;
using System.Collections.Generic;
using Gobbi.CoreServices.Security.Principal;
using Gobbi.services;

public partial class Vistas_ViewPopUpGrupoEmail : GobbiPage 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["__EVENTTARGET"] != null)
        {
            var sourceControl = Request.Params["__EVENTTARGET"].ToString();
            if (sourceControl.Contains("UpdateTimer"))
                return;
        }

    }

}
