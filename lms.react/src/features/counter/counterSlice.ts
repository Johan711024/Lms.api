import { createAsyncThunk, createSlice, PayloadAction } from '@reduxjs/toolkit'
import { RootState, AppThunk } from '../../app/store'

import { fetchCount, fetchGame, doFetchGameApi } from './counterApi'

export interface CounterState {
    value: string
    data: Array<any>

    status: 'idle' | 'loading' | 'failed'
}



const initialState:CounterState = {
    value: '',
    data: [],

    status: 'idle',
    
}

export const incrementAsync = createAsyncThunk(
    'counter/fetchCount',
    async (url:string) => {
        
        const response = await doFetchGameApi(url)
        console.log('createThunk: ' + JSON.stringify(response))

        //Se upp! Vanlig bugg. Om det skickas med en node i api som börjar med 'data' ska det stå response.data istället...
        return response
    }
)

export const counterSlice = createSlice({
    name: 'counter',
    initialState,
    reducers: {

    },
    extraReducers: (builder) => {
        builder
            .addCase(incrementAsync.pending, (state) => {
                state.status = 'loading'
            })
            .addCase(incrementAsync.fulfilled, (state, action:any) => {
                console.log('payload ' + JSON.stringify(action.payload))
                state.status = 'idle'                
                state.data = action.payload
            })
            .addCase(incrementAsync.rejected, (state) => {
                state.status = 'failed'
            })
        }
})

//export const {  } = counterSlice.actions

//game är ifrån store
export const selectCount = (state: RootState) => state.counter


export default counterSlice.reducer