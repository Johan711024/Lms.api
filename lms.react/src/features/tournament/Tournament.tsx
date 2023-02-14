import React, { useRef, useState, useEffect } from 'react'

import { useAppSelector, useAppDispatch } from '../../app/hooks'

import {
    selectTournament,
    getAsyncTournament
} from './tournamentSlice'


import {    
    getAsyncGame
} from '../game/gameSlice'

import styles from './Tournament.module.css'


export function Tournament() {
    const refHeaderLink = useRef(null)

    const [x, setX] = useState(0);
    const [y, setY] = useState(0);
    const [z, setZ] = useState(0);

    useEffect(() => {
        console.log('useEffect: ', x + ', ' + y)
        DragObject(refHeaderLink)
        //Runs only on the first render
    }, [x,y]);

    //console.log('refHeaderLink', refHeaderLink)

    const data = useAppSelector(selectTournament)
    const dispatch = useAppDispatch()


    const showGamesForTournament = (e:any) => {
        //console.log('dispatch games')
        dispatch(getAsyncGame('/tournaments/Johnny/Games/'))

        
    }

    const clickedTwoDObject = (e: any) => {
        
        //console.log('position: ', e.clientX + ', ' + e.clientY)
        setX(e.clientX)
        setY(e.clientY)

        dispatch(getAsyncTournament('/tournaments/'))
    }

    


    return (
        <div className={styles.Tournament}>
            

            <div className={styles.TwoDObject} ref={refHeaderLink} onMouseDown={(e) => clickedTwoDObject(e)}>Tournament: Johnny</div>

            <p>Tournaments:</p>
            {
                data.length > 0

                ?

                data.map((tournament: any, index: number) => {
                return (
                    <p key={index} onClick={(e)=>showGamesForTournament(e) }>{ tournament.title }</p>
                    )
                })

                :

                <p>Klicka</p>
                
            }
            


        </div>
    )
}




export const DragObject = ({ current }: any) => {
    let elem = current

    console.log('DragObject: ', elem)
    let pos1 = 0, pos2 = 0, pos3 = 0, pos4 = 0;

    const elementDrag = (e: any) => {
        //console.log('elementDrag: ', e)
        e = e || window.event;
        e.preventDefault();
        // calculate the new cursor position:
        pos1 = pos3 - e.clientX;
        pos2 = pos4 - e.clientY;
        pos3 = e.clientX;
        pos4 = e.clientY;
        // set the element's new position:
        elem.style.top = (elem.offsetTop - pos2) + "px";
        elem.style.left = (elem.offsetLeft - pos1) + "px";
    }

    const closeDragElement = () => {
        // stop moving when mouse button is released:
        document.onmouseup = null;
        document.onmousemove = null;
    }

    const dragMouseDown = (e: any) => {
        //console.log('dragMouseDown: ', elem)
        e = e || window.event
        e.preventDefault()

        pos3 = e.clientX
        pos4 = e.clientY

        document.onmouseup = closeDragElement

        // call a function whenever the cursor moves:
        document.onmousemove = elementDrag

    }
    
    if (elem ) {
       
        //console.log('If elem: ', elem)
        elem.onmousedown = dragMouseDown
    }
}
