import {combineReducers} from 'redux';
import lectureReducer from "./lectureReducer";
import answerReducer from "./answerReducer";
import profileReducer from "./profileReducer";

const reducers = combineReducers({
    lecture: lectureReducer,
    answer: answerReducer,
    profile: profileReducer
});

export default reducers;
