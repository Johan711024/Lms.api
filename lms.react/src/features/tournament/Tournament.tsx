import React, { useState } from 'react'

import { useAppSelector, useAppDispatch } from '../../app/hooks'

import {
    selectTournament,
    getAsyncTournament
} from './tournamentSlice'
import styles from './Tournament.module.css'


export function Tournament() {

    const data = useAppSelector(selectTournament)
    const dispatch = useAppDispatch()



    return (
        <div className={styles.Tournament}>
            

            <button onClick={(e) => dispatch(getAsyncTournament('/tournaments/'))}>Tournament: Johnny</button>

            <p>Tournaments:</p>
            {
                data.length > 0

                ?

                data.map((tournament: any, index: number) => {
                return (
                    <p key={ index }>{ tournament.title }</p>
                    )
                })

                :

                <p>Klicka</p>
                
            }
            


        </div>
    )
}

