using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buscador.Domain.com.clarin.entities;
using Buscador.Domain.com.clarin.filters;
using NUnit.Framework;
using NUnit.Mocks;

namespace Buscador.Domain.Test.banners
{
    [TestFixture]
    public class SearchParameterKeywordsProviderTest
    {
        [Test]
        [ExpectedException]
        public void Keywords_Provider_Throw_Exception_With_Empty_Fieldnames()
        {
            var keywordsProvider = new SearcParameterKeywordsProvider(new List<SelectedFilter>
                                                                          {
                                                                            new SelectedFilter("sl1","val1",true,1),
                                                                            new SelectedFilter("sl2","val2",true,2),
                                                                            new SelectedFilter("sl3","val3",true,3),
                                                                            new SelectedFilter("sl4","val4",true,4),
                                                                          },
                                                                      null);
        }

        [Test]
        public void Keywords_Provider_Should_Return_Parameters_String()
        {
            var keywordsProvider = new SearcParameterKeywordsProvider(new List<SelectedFilter>
                                                                          {
                                                                            new SelectedFilter("sl1","val1",true,1),
                                                                            new SelectedFilter("sl2","val2",true,2),
                                                                            new SelectedFilter("sl3","val3",true,3),
                                                                            new SelectedFilter("sl4","val4",true,4),
                                                                          }, 
                                                                      new Dictionary<string, string>
                                                                          {
                                                                              {"id_marca", "sl1"},
                                                                              {"id_model", "sl2"},
                                                                              {"provinci", "sl3"},
                                                                              {"localida", "sl4"}
                                                                          });

            var parameters = "kw_marcas=Request(\"id_marca\")&amp;kw_MarcMod=Request(\"id_modelo\")&amp;kw_provincias=Request(\"provincia\")&amp;kw_localidades=Request(\"localidad\")&amp;kw_nuevousado=Request(\"1\")";

            var parametersConverted = keywordsProvider.GetParametersString(parameters, string.Empty);

            Assert.AreEqual(parametersConverted, "kw_marcas=val1&amp;kw_MarcMod=val2&amp;kw_provincias=val3&amp;kw_localidades=val4");
        }

        [Test]
        public void Banner_Tohtml_Should_Not_Be_Empty()
        {
            var keywordsProviderMock = new DynamicMock(typeof (IKeywordsProvider));

            var parametersReturn = "kw_marcas=val1&amp;kw_MarcMod=val2&amp;kw_provincias=val3&amp;kw_localidades=val4";

            keywordsProviderMock.SetReturnValue("GetParametersString",parametersReturn);

            var banner = new Banner
                             {
                                 KeywordsProvider = (IKeywordsProvider) (keywordsProviderMock.MockInstance),
                                 Behaviour = "parametros",
                                 Zone = "zone",
                                 Provider = "eplanning"
                             };

            var html = banner.GetHtml();

            Assert.IsFalse(string.IsNullOrEmpty(html));
            Assert.IsTrue(html.Contains(parametersReturn));
        }
    }
}
