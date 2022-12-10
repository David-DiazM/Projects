function notWorking() {
    alert("This feature does not work");
}

function getData() {
    // var myPlanets = '[ \
    //     {"name": "Mercury", "id": 1, "imagePath": "images/mercury.jpg", "moons": 0, "orbitInDays": 88, "gravitationalPull": 3.70}, \
    //     {"name": "Venus", "id": 2, "imagePath": "images/venus.jpg", "moons": 0, "orbitInDays": 225, "gravitationalPull": 8.90}, \
    //     {"name": "Earth", "id": 3, "imagePath": "images/earth(1).jpg", "moons": 1, "orbitInDays": 365, "gravitationalPull": 9.80} \
    // ]';

    var myPlanets = "[";

    //planet 1
    myPlanets = myPlanets + "{";
    myPlanets = myPlanets + '"name": "Mercury", ';
    myPlanets = myPlanets + '"id": 1, ';
    myPlanets = myPlanets + '"imagePath": "images/mercury.jpg", ';
    myPlanets = myPlanets + '"moons": 0, ';
    myPlanets = myPlanets + '"orbitInDays": 88, ';
    myPlanets = myPlanets + '"gravitationalPull": 3.70';
    myPlanets = myPlanets + "},";

    //planet 2
    myPlanets = myPlanets + "{";
    myPlanets = myPlanets + '"name": "Venus", ';
    myPlanets = myPlanets + '"id": 2, ';
    myPlanets = myPlanets + '"imagePath": "images/venus.jpg", ';
    myPlanets = myPlanets + '"moons": 0, ';
    myPlanets = myPlanets + '"orbitInDays": 225, ';
    myPlanets = myPlanets + '"gravitationalPull": 8.90';
    myPlanets = myPlanets + "},";

    //planet 3
    myPlanets = myPlanets + "{";
    myPlanets = myPlanets + '"name": "Earth", ';
    myPlanets = myPlanets + '"id": 3, ';
    myPlanets = myPlanets + '"imagePath": "images/earth(1).jpg", ';
    myPlanets = myPlanets + '"moons": 1, ';
    myPlanets = myPlanets + '"orbitInDays": 365, ';
    myPlanets = myPlanets + '"gravitationalPull": 9.80';
    myPlanets = myPlanets + "}";

    myPlanets = myPlanets + "]"
    
    var data = JSON.parse(myPlanets);
    console.log("the Planets", data);

    //...iterate it
    var generatedHtml = "";
    for (var i = 0; i < data.length; i++)
    {
        //...compose html for each item
        generatedHtml += '<div class="row">';
        generatedHtml += '<div class="panel panel-default">';
        generatedHtml += '<div class="panel-heading lead">';
        generatedHtml += '<b>' + data[i].name + ' : ' + data[i].id + '</b>&nbsp;';
        generatedHtml += '</div>';
        generatedHtml += '<div class="panel-body">';
        generatedHtml += '<img class="panelimg" src="' + data[i].imagePath + '" />';
        generatedHtml += '</div>';
        generatedHtml += '<div class="panel-body">';
        generatedHtml += '<ul>';
        generatedHtml += '<li>' + data[i].moons + ' Moon(s)</li>';
        generatedHtml += '<li>Days in Orbit: ' + data[i].orbitInDays + ' days</li>';
        generatedHtml += '<li>Gravitational Pull(m/s<sup>2</sup>): ' + data[i].gravitationalPull + '</li>';
        generatedHtml += '</ul>';
        generatedHtml += '</div>';
        generatedHtml += '</div>';
        generatedHtml += '</div>';
    }
    
    //..inject into form
    document.getElementById("myPlanets").innerHTML = generatedHtml;
}