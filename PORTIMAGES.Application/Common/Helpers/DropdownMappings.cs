using PORTIMAGES.Application.Common.Models; 

namespace PORTIMAGES.Application.Common.Helpers
{
    public static class DropdownMappings
    {
        public static DropdownConfig Get(string key)
        {
            return key switch
            {
                "SHIPTYPE" => new DropdownConfig
                {
                    TableName = "ShipType",
                    ValueField = "ID",
                    TextField = "TypeName",
                    OrderBy = "TypeName"
                },
                "SHIPPING" => new DropdownConfig
                {
                    TableName = "Shipping",
                    ValueField = "ID",
                    TextField = "Name",
                    OrderBy = "Name"
                },
                "PORT" => new DropdownConfig
                {
                    TableName = "PortMaster",
                    ValueField = "ID",
                    TextField = "PortName",
                    OrderBy = "PortName"
                },

                "TERMINAL" => new DropdownConfig
                {
                    TableName = "TerminalMaster",
                    ValueField = "ID",
                    TextField = "TerminalName",
                    FilterField = "PortID",
                    OrderBy = "TerminalName"
                },
                "COUNTRY" => new DropdownConfig
                {
                    TableName = "CountryMaster",
                    ValueField = "ID",
                    TextField = "CountryName",
                    FilterField = "ID",
                    OrderBy = "CountryName"
                },
                "SHIPUSE" => new DropdownConfig
                {
                    TableName = "ShipUse",
                    ValueField = "ID",
                    TextField = "UseType",
                    FilterField = "ID",
                    OrderBy = "UseType"
                },

                

                _ => throw new Exception("Invalid dropdown key")
            };
        }
    }
}
