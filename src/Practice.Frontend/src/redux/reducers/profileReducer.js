const profileReducer = (state = {}, action) => {
    switch (action.type) {
        case 'GET_PROFILE':
            return {...state, ...action.item};
        default:
            return state;
    }
};

export default profileReducer;
