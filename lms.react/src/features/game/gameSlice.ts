import { createAsyncThunk, createSlice, PayloadAction } from '@reduxjs/toolkit'
import { RootState, AppThunk } from '../../app/store'

import { doFetchGameApi } from './gameApi'

export interface GameState {  
    //f�rst�r ej 'value'. Vet inte var eller hur den s�tts men den m�ste vara med f�r att det ska fungera.
    value: Array<any>
    status: 'idle' | 'loading' | 'failed'
}



const initialState: GameState = {    
    value: [],
    status: 'idle',
    
}

export const getAsyncGame = createAsyncThunk(
    'game/fetchGame',
    async (url:string) => {
        console.log('createThunk')
        const response = await doFetchGameApi(url)

        //Se upp! Vanlig bugg. Om det skickas med en node i api som b�rjar med 'data' ska det st� response.data ist�llet...
        return response
    }
)

export const gameSlice = createSlice({
    name: 'Game',
    initialState,
    reducers: {

    },
    extraReducers: (builder) => {
        builder
            .addCase(getAsyncGame.pending, (state) => {
                state.status = 'loading'
            })
            .addCase(getAsyncGame.fulfilled, (state, action:any) => {
                console.log('hello ' + JSON.stringify(action))
                state.status = 'idle'
                state.value = action.payload
                

            })
            .addCase(getAsyncGame.rejected, (state) => {
                state.status = 'failed'
            })
        }
    })

//game �r ifr�n store
export const selectGame = (state: RootState) => {
    const { value } = state.game

    return value

}


export default gameSlice.reducer