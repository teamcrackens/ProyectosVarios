

const FETCH_START ='start'
const FETCH_SUCCESS ='success'
const FETCH_ERROR ='error'

const fetchStart = () => ({
    type: FETCH_START,
})

const fetchSuccess = payload => ({
    type: FETCH_SUCCESS,
    payload 
})

const fetchError = error => ({
    type: FETCH_ERROR,
    error
})
const url = 'https://jsonplaceholder.typicode.com/users'
const initialState = {
    data:[],
    fetching: false,
    error: null,
}
function reducer (state= initialState, action){
    switch (action.type) {
        case FETCH_START:
            return {
                ...state,
                fetching:true,
            }
        case FETCH_ERROR:
            return {
                ...state,
                error: action.error,
            }
        case FETCH_SUCCESS:
            return {
                ...state,
                data: action.payload,
            }
        default:
            return state
    }
}

export default payload =>
 async (dispatch, getState) => {
    dispatch(fetchStart) 
    try {
       const result = await fetch(url)
       const resultJson = result.json()
       dispatch(fetchSuccess(resultJson)) 
       console.log(resultJson)
     } catch (error) {
         const errorJson = error.json()
         dispatch(fetchError(errorJson))
         console.log(errorJson)
     }
}