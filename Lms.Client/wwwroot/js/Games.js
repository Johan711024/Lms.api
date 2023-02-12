import { doApiFetch } from "./doApiFetch.js"
import { RenderOwnerList } from "./renderGamesList.js" 



const searchOwner = async (e) => {
    console.log(e.target.value)

    

    const owners = await doApiFetch('/Api/SearchOwner')

    await console.log('result', owners)

    let searchString = e.target.value.toLowerCase()

    console.log('searchString', searchString)

    
    var searchResultOwners = owners.filter(item => item.socialSecurityNumber.toLowerCase().indexOf(searchString)!=-1)

    console.log('searchResultOwners',searchResultOwners)

    searchString.length > 2 && RenderOwnerList(nodeResult, searchResultOwners, itemClicked)


}

const itemClicked = async (itemIndex) => {
  
    console.log('clicked on: ', itemIndex)

    location.href =`/Vehicles/ParkVehicle?vehicleId=${itemIndex}`
}


const getGames = async(tournament) => {
    const reqUrl ="https://localhost:7255"
    const games = await doApiFetch(`${reqUrl}/api/tournaments/${tournament}/games`)
    //alert(JSON.stringify(owners))
    //nodeResult.insertAdjacentHTML('beforeend', JSON.stringify(owners))
    let html=""
    games.forEach(game => { 
        html += `<p>${game.title}</p>`
    })
    nodeResult.innerHTML = html
}



document.querySelectorAll(".game").forEach(lnk => lnk.addEventListener("mouseover", (e) => getGames(e.target.getAttribute("data-id"))))

document.querySelectorAll(".game").forEach(lnk => lnk.addEventListener("mouseout", (e) => nodeResult.innerHTML =""))

const nodeResult = document.querySelector('#result')








