import React, { useState } from 'react'

import { useAppSelector, useAppDispatch } from '../../app/hooks'

import {
    selectGame,
    getAsyncGame
} from './gameSlice'
import styles from './Game.module.css'


export function Game() {

    const data = useAppSelector(selectGame)
    const dispatch = useAppDispatch()



    return (
        <div className={styles.Game}>
            

            <button onClick={(e) => dispatch(getAsyncGame('/tournaments/Johnny/Games/'))}>Tournament: Johnny</button>

            <p>Games:</p>
            {
                data.length > 0

                ?

                data.map((game: any, index: number) => {
                return (
                    <p key={ index }>{ game.title }</p>
                    )
                })

                :

                <p>Klicka</p>
                
            }
            


        </div>
    )
}

