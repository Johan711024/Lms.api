import { doApiFetch } from "./doApiFetch.js"

const RenderOwnerList = async (node, memberList, itemClickedFunc ) => {

    let html = '<ul  class="list-group" style="width: 450px" id="idHtmlList" >'

    console.log('memberlist',memberList)

    for (let i = 0; i < memberList.length; i++) {
        html += '<li class="list-group-item" style="background-color: #fcfcfc">'
        //html += `<a class="remove" id="btn${i}" data-id="${i}" style="color: red; cursor: grab">Välj</a>&nbsp;&nbsp;&nbsp;`
        html += `<div style="margin-bottom: 32px">${memberList[i].firstName} ${memberList[i].lastName} -  ${memberList[i].socialSecurityNumber}`

        const vehicles = await doApiFetch('/Api/SearchVehicle/' + memberList[i].ownerId)
        console.log('searchResultvehicles', vehicles)

        for (let j = 0; j < vehicles.length; j++) {
            //html += `<p><a href="/Vehicles/ParkVehicle?vehicleId=${vehicles[j].vehicleId}" style="cursor: grab" class="textlnk" id="lnk${vehicles[j].regNumber}" data-id="${vehicles[j].regNumber}">${vehicles[j].regNumber}</a></p>`
            html += `<div   style="display:block; cursor: grab; margin:16px; padding: 8px 32px 8px 32px; color: cornflowerblue; background-color: white" onMouseOver="this.style.backgroundColor='#eeeeee'"
   onMouseOut="this.style.backgroundColor='#ffffff'" class="textlnk btn border border-gray" id="lnk${vehicles[j].vehicleId}" data-id="${vehicles[j].vehicleId}">
                    ${vehicles[j].regNumber} - ${vehicles[j].brand}, ${vehicles[j].color}
            
            </div>`
        }
        html += `<p style="padding-top: 30px"><button onclick="location.href='/Vehicles/AddVehicleOnOwner?socialSecurityNumber=${memberList[i].socialSecurityNumber}&ownerFullName=${memberList[i].firstName} ${memberList[i].lastName}&ownerId=${memberList[i].ownerId}'" class="btn btn-default border border-gray w3-display-bottomright" style="background-color: blue;  color: white; margin:32px; padding: 8px 32px 8px 32px">ADD NEW</button></p>`

        html +=`</div>`
        html += '</li>'
    }
    html += '</ul>'

    const prevHtmlList = document.querySelector('#idHtmlList')
    prevHtmlList && prevHtmlList.remove()

    node.insertAdjacentHTML('beforeend', html)

    /*
    document.querySelectorAll(".remove").forEach(btn =>
        btn.addEventListener("click", (e) => removeItemFunc(e.target.getAttribute("data-id")))
    )
    */

    document.querySelectorAll(".textlnk").forEach(lnk =>
        lnk.addEventListener("click", (e) => itemClickedFunc(e.target.getAttribute("data-id")))
    )
    

}

export { RenderOwnerList }