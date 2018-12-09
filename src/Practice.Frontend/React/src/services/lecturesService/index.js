import axios from 'axios';

class LecturesService {
    static getLecture = (lectureId) =>
        axios.get(`/lectures/${lectureId}`)
            .then(({data}) => data);

    static sendAnswer = (session, data) => axios.post('/quizzes', {
            ...data
        },
        {
            params: {session}
        })
        .then(({data}) => data)
}

export default LecturesService;