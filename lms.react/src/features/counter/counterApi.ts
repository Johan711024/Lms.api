

export const doFetchGameApi = async (parametersUrl: string) => {
    
    ///api/tournaments/Johnny/Games/
    
    let url = `https://localhost:7255/api${parametersUrl}`

    console.log(url)

    const response = await fetch(
        url,
        {
            method: 'GET',
            headers: {
                'content-type': 'application/json;charset=UTF-8',
            }
        }
        
    )

    if (!response.ok) { throw new Error('http error ' + response.status) }

    const data = await response.json()

    return data
}


//POST: https://kentcdodds.com/blog/using-fetch-with-type-script
//const response = await window.fetch('https://graphql-pokemon2.vercel.app/', {
//    // learn more about this API here: https://graphql-pokemon2.vercel.app/
//    method: 'POST',
//    headers: {
//        'content-type': 'application/json;charset=UTF-8',
//    },
//    body: JSON.stringify({
//        query: pokemonQuery,
//        variables: { name: name.toLowerCase() },
//    }),
//})




export const fetchCount = (amount = 1) => {
    return new Promise<{data:number}>((resolve) =>

        setTimeout(
            () =>
                resolve(
                    {
                        data: amount
                    }
                ),
            500
        )
    )
}


export const fetchGame = (amount = 1) => {
    return new Promise<{ data: Array<any> }>((resolve) =>

        setTimeout(
            () =>
                resolve(
                    {
                        data: [
                            {
                            value: amount,
                            title: 'game1'
                            }
                        ]
                    }
                ),
            500
        )
    )
}