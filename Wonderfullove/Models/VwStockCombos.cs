using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wonderfullove.Models;

[Keyless]
public partial class VwStockCombos
{
    public int ComboProductoId { get; set; }

    public int? StockDisponible { get; set; }
}
