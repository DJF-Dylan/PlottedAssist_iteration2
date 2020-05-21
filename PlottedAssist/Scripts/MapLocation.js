const TOKEN = "pk.eyJ1IjoiZHlsYW4xMjAxIiwiYSI6ImNrYWdidW5sMjAya3EycW9laTZ0b3VlN3UifQ.GAPLpZajWbgf9PxReUBjqw";
var locations = [{
        "latitude": -37.79204520,
        "longitude": 145.00720370,
        "address": "Yarra Bend Rd, Fairfield VIC 3078",
        "description": "Yarra Edge Nursery"
    }, {
        "latitude": -37.7955420,
        "longitude": 144.97698130,
        "address": "390 Brunswick St, Fitzroy VIC 3065",
        "description": "Fitzroy Nursery"
    }, {
        "latitude": -37.82479340,
        "longitude": 144.99220350,
        "address": "52-54 Stanley St, Richmond VIC 3121",
        "description": "Glasshaus Outside"
    }, {
        "latitude": -37.78276720,
        "longitude": 144.98193920,
        "address": "257 St Georges Rd, Fitzroy North VIC 3068",
        "description": "Northroy Nursery"
    }, {
        "latitude": -37.8457060,
        "longitude": 144.99060730,
        "address": "Shop 119, Prahran Market, 9 Elizabeth Street, South Yarra VIC 3141",
        "description": "Prahran Garden Centre"
    }, {
        "latitude": -37.77892060, 
        "longitude": 145.00976820,
        "address": "85 South Cres, Northcote VIC 3070",
        "description": "Northcote Nursery"
    }, {
        "latitude": -37.7712590,
        "longitude": 144.96935570,
        "address": "245 Lygon St, Brunswick East VIC 3057",
        "description": "Lygon St Nursery"
    }, {
        "latitude": -37.7955420,
        "longitude": 144.97698130,
        "address": "390 Brunswick St, Fitzroy VIC 3065",
        "description": "The Artists Garden"
    }, {
        "latitude": -37.8154810,
        "longitude": 145.01919630,
        "address": "67 Church St, Hawthorn VIC 3122",
        "description": "Bonsai Farm"
    }, {
        "latitude": -37.80540770,
        "longitude": 144.98341460,
        "address": "33 Peel St, Collingwood VIC 3066",
        "description": "My Jungle Home"
    }, {
        "latitude": -37.80590970,
        "longitude": 144.98661920,
        "address": "81 Rupert St, Collingwood VIC 3066",
        "description": "The Plant Exchange"
    }, {
        "latitude": -37.8587390, 
        "longitude": 144.99956930,
        "address": "255-257 Dandenong Rd, Prahran VIC 3181",
        "description": "Julian Ronchi Garden Design & Nursery"
    }, {
        "latitude": -37.8264610, 
        "longitude": 144.98853330,
        "address": "44 Cremorne St, Cremorne VIC 3121",
        "description": "Glasshaus Inside"
    }, {
        "latitude": -37.81122880, 
        "longitude": 144.96477050,
        "address": "corner Swanston &, Lonsdale St, Melbourne VIC 3000",
        "description": "A Prickly Affair"
    }, {
        "latitude": -37.7756060,
        "longitude": 144.95993910,
        "address": "90-106 Sydney Rd, Brunswick VIC 3056",
        "description": "Plan Plant Planet"
    }
];

var data = [];
for (i = 0; i < locations.length; i++) {
    var feature = {
        "type": "Feature",
        "properties": {
            "description": locations[i].description,
            "address": locations[i].address,
            "icon": "circle-15"
        },
        "geometry": {
            "type": "Point",
            "coordinates": [locations[i].longitude, locations[i].latitude]
        }
    };
    data.push(feature)
}
mapboxgl.accessToken = TOKEN;
var map = new mapboxgl.Map({
    
    container: 'map',
    style: 'mapbox://styles/mapbox/streets-v10',
    zoom: 12,
    center: [144.97985220, -37.80052180]
});
map.on('load', function () {
    // Add a layer showing the places.
    map.addLayer({
        "id": "places",
        "type": "symbol",
        "source": {
            "type": "geojson",
            "data": {
                "type": "FeatureCollection",
                "features": data
            }
        },
        "layout": {
            "icon-image": "{icon}",
            "icon-allow-overlap": true
        }
    });
    map.addControl(new MapboxGeocoder({ 
        accessToken: mapboxgl.accessToken
 }));;
map.addControl(new mapboxgl.NavigationControl());
// When a click event occurs on a feature in the places layer, open a popup at the
// location of the feature, with description HTML from its properties.
map.on('click', 'places', function (e) {
    var coordinates = e.features[0].geometry.coordinates.slice();
    var description = e.features[0].properties.description;
    var address = e.features[0].properties.address;
    // Ensure that if the map is zoomed out such that multiple
    // copies of the feature are visible, the popup appears
    // over the copy being pointed to.
    while (Math.abs(e.lngLat.lng - coordinates[0]) > 180) {
        coordinates[0] += e.lngLat.lng > coordinates[0] ? 360 : -360;
    }
    new mapboxgl.Popup()
        .setLngLat(coordinates)
        .setHTML(description + "<br>" +address)
        .addTo(map);
});
// Change the cursor to a pointer when the mouse is over the places layer.
map.on('mouseenter', 'places', function () {
    map.getCanvas().style.cursor = 'pointer';
});
// Change it back to a pointer when it leaves.
map.on('mouseleave', 'places', function () {
    map.getCanvas().style.cursor = '';
});
});
