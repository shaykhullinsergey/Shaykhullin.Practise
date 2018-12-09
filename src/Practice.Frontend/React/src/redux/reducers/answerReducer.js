const answerReducer = (state = {}, action) => {
    switch (action.type) {
        case 'SET_ANSWER':
            return {...state, ...action.item};
        default:
            return state;
    }
};

export default answerReducer;