using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace bp02_Calculator.Models;

public class SavedCalculationsModel
{
  public int id { get; set; }
  public string calculation { get; set; }
}