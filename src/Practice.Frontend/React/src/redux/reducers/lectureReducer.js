const lectureReducer = (state = {}, action) => {
    switch (action.type) {
        case 'SET_LECTURE':
            return {...state, ...action.item};
        default:
            return state;
    }
};

export default lectureReducer;