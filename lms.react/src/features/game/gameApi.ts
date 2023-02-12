export const fetchGame = () => new Promise((resolve) =>

    setTimeout(
        () =>
            resolve(
                {
                    title: 'game1'
                }
            ),
        500
    )
)
