using AppLogic.UCInterfaces;
using Domain.Entities;
using DTOs;
using EcosystemApp.Globals;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ecosystem_Web_API
{
    public class CountryLoader
    {

        public IListCountries ListUC { get; set; }
        public IAddCountry AddUC { get; set; }

        public CountryLoader(IListCountries listUC, IAddCountry addUC)
        {
            ListUC = listUC;
            AddUC = addUC;
        }
        public void LoadCountries()
        {
            if (ListUC.List().Count == 0)
            {
                string url = "https://restcountries.com/v3.1/all?fields=name,cca3";

                var response = Global.GetResponse(url);

                var content = Global.GetContent(response);

                if (response.IsSuccessStatusCode)
                {
                    
                    List<RestApiCountryDTO> countries = JsonConvert.DeserializeObject<List<RestApiCountryDTO>>(content);

                    foreach (var c in countries)
                    {
                        try
                        {
                        Country country = c.TransformToObj();
                        AddUC.Add(country);
                        }
                        catch ( Exception e )
                        { 
                            string msg = e.Message;
                            //este catch es para debugear y para que siga subiendo paises aunque alguno tire excepcion.
                        }
                    }
                }
            }
        }
    }
}
