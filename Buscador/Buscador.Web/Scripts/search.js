function initializeSearch(urlBrands, urlModels, urlVersions) {
    $.ajax(
        {
            url: urlBrands,
            contentType: "application/json",
            dataType: "json",
            success: function (data) {
                FillCombo(data, "VehicleBrands");
            }
        });
        
    $("#VehicleBrands").change(function () {

        if ($("#VehicleBrands").val() != "-1") {
            $.ajax({
                url: urlModels,
                data: "id=" + $("#VehicleBrands").val(),
                success: function (data) {
                    FillCombo(data, "VehicleModels");
                }
            });
        }
    });
    
    $("#VehicleModels").change(function () {

        if ($("#VehicleModels").val() != "-1") {
            $.ajax({
                url: urlVersions,
                data: "id=" + $("#VehicleModels").val(),
                success: function (data) {
                    FillCombo(data, "VehicleVersions");
                }
            });
        }
    });

    $("#btnSearch").click(function () {

        /*url example: http://www.deautos.com/autos-usados-fiat-idea/VTYY1WWMAYY370WWMOYY2774WWVEYY47859WWYEYY2000-2010 */

        var vehicletype = "";
        var brand = "";
        var model = "";
        var version = "";

        url = "http://www.deautos.com/autos";

        if ($("input[name='buscarOtroAuto']:checked").attr('checked')) {
            url += "-" + $("input[name='buscarOtroAuto']:checked").val();
            vehicletype = "VTYY" + $("input[name='buscarOtroAuto']:checked").attr('vehicletype');
        }

        if ($("#VehicleBrands").val() != "-1") {
            url += "-" + $("#VehicleBrands option:selected").text().toLowerCase();
            brand = $("#VehicleBrands option:selected").attr("searchText") + "YY" + $("#VehicleBrands").val();
        }

        if ($("#VehicleModels").val() != "-1" && $("#VehicleModels").val() != null) {
            url += "-" + $("#VehicleModels option:selected").text().toLowerCase();
            model = $("#VehicleModels option:selected").attr("searchText") + "YY" + $("#VehicleModels").val();
        }

        if ($("#VehicleVersions").val() != "-1" && $("#VehicleVersions").val() != null) {
            version = $("#VehicleVersions option:selected").attr("searchText") + "YY" + $("#VehicleVersions").val();
        }

        url += "/";

        if (vehicletype != "")
            url += vehicletype + "WW";

        if (brand != "")
            url += brand + "WW";

        if (model != "")
            url += model + "WW";

        if (version != "")
            url += version + "WW";

        if ($("#sincedate").val() != "" && $("#todate").val() != "")
            url += "YEYY" + $("#sincedate").val() + "-" + $("#todate").val();

        if (url.substring(url.length - 2, url.length) == "WW")
            url = url.substring(0, url.length - 2);

        // alert(url);
        window.open(url, '_newtab');
        //window.location.href = url;

    });
}

function FillCombo(data, combo) {
    /*EL JASON TIENE LLEGAR ASI PARA PODER PARSEARLO:
    '{ "Result": [{"Name":"Volkswagen","ResultsFound":"2942","Url":"/autos-volkswagen/MAYY395","SliceKey":"MA","SliceValue":"395","_type":"HierarchicalFacet","Value":null},{"Name":"Volkswagen","ResultsFound":"2942","Url":"/autos-volkswagen/MAYY395","SliceKey":"MA","SliceValue":"395","_type":"HierarchicalFacet","Value":null}]}' 
    */
    obj = JSON.parse(data);
    //obj = JSON.parse(JSON.stringify(data));
    //alert(obj);
    //obj = JSON.parse(data);
    var listItems = "<option value='-1' searchText='-1' >Seleccionar..</option>";
    //alert(obj.Results.length);
   
    //alert(obj.Results[5]);
    for (var i = 0; i < obj.Results.length; i++) {
        listItems += "<option value='" + obj.Results[i].SliceValue + "' searchText='" + obj.Results[i].SliceKey + "' >" + obj.Results[i].Name + "</option>";
    }
   
    $("#" + combo).html(listItems);
}


