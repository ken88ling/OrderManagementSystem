using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Data.Models.Mapping
{
    public class SaleLineItemMap : EntityTypeConfiguration<SaleLineItem>
    {
        public SaleLineItemMap()
        {
            //primary key
            this.HasKey(t => new { t.SaleId, t.ProductId });

            //property
            this.Property(t => t.Quantity)
                .HasColumnType("smallint")
                .IsRequired();

            this.Property(t => t.UnitPrice)
                .HasColumnType("money")
                .IsRequired();

            // table and column mappings


            //relationships
            this.HasRequired(t => t.Product)
                .WithMany(t => t.SaleLineItemList)
                .HasForeignKey(d => d.ProductId);

            this.HasRequired(t => t.Sale)
                .WithMany(t => t.SaleLineItemlist);
        }
    }
}
