﻿using System;
using System.Collections.Generic;
using System.Text;
using WLightBoxApi.Models;

namespace WLightBoxApi.Contracts
{
    /// <summary>
    /// Model for Json Contract. Used in GET /api/rgbw/state Api
    /// </summary>
    public class RgbwResponse
    {
        public Rgbw rgbw { get; set; }

    }
}
