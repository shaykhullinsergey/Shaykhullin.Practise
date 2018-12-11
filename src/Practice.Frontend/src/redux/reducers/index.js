import {combineReducers} from 'redux';
import lectureReducer from "./lectureReducer";
import answerReducer from "./answerReducer";

const reducers = combineReducers({
    lecture: lectureReducer,
    answer: answerReducer
});

export default reducers;