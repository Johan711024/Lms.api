


const doApiFetch = async (url) => {
    //console.log(url)

    const response = await fetch(
        url,
        {
            method: 'GET',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
        }
    )

    if (!response.ok) { throw new Error('http error ' + response.status) }

    const data = await response.json()

    return data
}

export { doApiFetch }