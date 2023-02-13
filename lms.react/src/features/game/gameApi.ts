
export const doFetchGameApi = async (parametersUrl: string) => {

    ///api/tournaments/Johnny/Games/

    //let url = `https://localhost:7255/api/tournaments/${parametersUrl}/Games/`

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