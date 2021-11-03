var newItemCounter = 1;
var ourList = document.getElementById("list");
var ourButton = document.getElementById("ourButton");
var ourHeader = document.getElementById("header");
var listItems = document.getElementById("list").getElementsByTagName("li");

ourList.addEventListener("click", activateItem);

function activateItem(e)
{
    if(e.target.nodeName == "LI")
    {
        ourHeader.innerHTML = e.target.innerHTML;

        for(i=0; i < e.target.parentNode.children.length; i++)
        {
            e.target.parentNode.children[i].classList.remove("active");
        }
    
        e.target.classList.add("active");
    }
}

ourButton.addEventListener("click", createNewItem);

function createNewItem()
{
    ourList.innerHTML += "<li>something new " + newItemCounter + "</li>";
    newItemCounter++;
}