import React, { useState } from 'react'

import { useAppSelector, useAppDispatch } from '../../app/hooks'

import {
    selectCount,
    incrementAsync
} from './counterSlice'

import styles from './Game.module.css'


export function Counter() {

    const { data } = useAppSelector(selectCount)
    const counterState = useAppSelector(selectCount)
    const dispatch = useAppDispatch()



    return (
        <div className={styles.Game}>

            <div onClick={(e) => dispatch(incrementAsync('/tournaments/Johnny/Games/'))}>Game page</div>

            <div onClick={(e) => console.log('console')}>Console</div>

            <div>All Data |{JSON.stringify(data)}|</div>

            
            <div>CounterState |{JSON.stringify(counterState)}|</div>




        </div>
    )
}

