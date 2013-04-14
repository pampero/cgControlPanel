var map;
var geocoder;

function initialize() {
    map = new GMap2(document.getElementById("map_canvas"));

    map.addControl(new GSmallMapControl());
    map.addControl(new GMapTypeControl());

    geocoder = new GClientGeocoder();
    if (document.getElementById("gmap_punto").value == '') {
        //alert(document.getElementById("gmap_punto").value);
        //showLocation()
    } else {
        var point = new GLatLng(document.getElementById("gmap_punto").value.split(",")[0], document.getElementById("gmap_punto").value.split(",")[1]);
        map.setCenter(point, 15);
        marker = new GMarker(point, { draggable: true });
        map.addOverlay(marker);
        //marker.openInfoWindowHtml(direccion);
    }
}
function addAddressToMap(response) {
    map.clearOverlays();
    if (!response || response.Status.code != 200) {
        alert("Lo sentimos, no se ha encontrado su direcci&ocute;n");
    } else {
        place = response.Placemark[0];
        point = new GLatLng(place.Point.coordinates[1], place.Point.coordinates[0]);

        map.setCenter(point, 15);

        marker = new GMarker(point, { draggable: true });


        map.addOverlay(marker);
        marker.openInfoWindowHtml(place.address);
        document.getElementById("gmap_punto").value = marker.getLatLng().toUrlValue();


    }
}
function showLocation() {
    var address = document.getElementById("Direccion").value;
    var prov = document.getElementById("txtzona").value;
    prov = prov.replace("[Capital Federal]", "[Buenos Aires]");
    prov = prov.replace("[Gran Buenos Aires]", "[Buenos Aires]");
    geocoder.getLocations(address + " " + prov + ", Argentina", addAddressToMap);
} 