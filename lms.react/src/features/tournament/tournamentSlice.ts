import { createAsyncThunk, createSlice, PayloadAction } from '@reduxjs/toolkit'
import { RootState, AppThunk } from '../../app/store'

import { doFetchTournamentApi } from './tournamentApi'

export interface TournamentState {  
    //förstår ej 'value'. Vet inte var eller hur den sätts men den måste vara med för att det ska fungera.
    value: Array<any>
    status: 'idle' | 'loading' | 'failed'
}



const initialState: TournamentState = {    
    value: [],
    status: 'idle',
    
}

export const getAsyncTournament = createAsyncThunk(
    'tournament/fetchTournament',
    async (url:string) => {
        //console.log('createThunk')
        const response = await doFetchTournamentApi(url)

        //Se upp! Vanlig bugg. Om det skickas med en node i api som börjar med 'data' ska det stå response.data istället...
        return response
    }
)

export const tournamentSlice = createSlice({
    name: 'tournament',
    initialState,
    reducers: {

    },
    extraReducers: (builder) => {
        builder
            .addCase(getAsyncTournament.pending, (state) => {
                state.status = 'loading'
            })
            .addCase(getAsyncTournament.fulfilled, (state, action:any) => {
                //console.log('action ' + JSON.stringify(action))
                state.status = 'idle'
                state.value = [...action.payload]
                

            })
            .addCase(getAsyncTournament.rejected, (state) => {
                state.status = 'failed'
            })
        }
    })


export const selectTournament = (state: RootState) => {
    //tournament är ifrån 'store'
    const { value } = state.tournament
    //returnerar 'value' till txs...där den refaktoreras till sina underliggande beståndsdelar... Titta i redux-tools
    return value

}


export default tournamentSlice.reducer