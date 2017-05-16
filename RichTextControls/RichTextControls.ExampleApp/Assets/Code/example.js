var text = ''
var i = 0;
// Print the numbers
do {
    text += '<br>The number is ' + i;
    i++;
}
while (i < 10);  

document.getElementById("demo").innerHTML = text;