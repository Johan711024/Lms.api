
import { configureStore, ThunkAction, Action } from '@reduxjs/toolkit'
import tournamentReducer from '../features/tournament/tournamentSlice'
import gameReducer from '../features/game/gameSlice'
import counterReducer from '../features/counter/counterSlice'



export const store = configureStore({
    reducer: {
        tournament: tournamentReducer,
        game: gameReducer,
        counter: counterReducer

    }
})


export type AppDispatch = typeof store.dispatch
export type RootState = ReturnType<typeof store.getState>
export type AppThunk<ReturnType = void> = ThunkAction<ReturnType, RootState, unknown, Action<string>>