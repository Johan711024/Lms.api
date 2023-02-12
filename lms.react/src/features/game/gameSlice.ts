import { createAsyncThunk, createSlice, PayloadAction } from '@reduxjs/toolkit'
import { RootState, AppThunk } from '../../app/store'

import { fetchGame } from './gameApi'

export interface GameState {
    games: Array<{ key: string, value: string }>

    status: 'idle' | 'loading' | 'failed'
}



const initialState: GameState = {
    games: [],
    status: 'idle'
}

export const getAsyncGame = createAsyncThunk(
    'game/fetchGame',
    async () => {
        const response = await fetchGame()

        return response
    }
)

export const gameSlice = createSlice({
    name: 'Game',
    initialState,
    reducers: {

    },
    extraReducers: () => { }
    })

export const selectGame = (state: RootState) => state.games


export default gameSlice.reducer