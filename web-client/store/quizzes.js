const initState = () => ({
  quizzes: []
})

export const state = initState

export const mutations = {
  setQuizzes(state, {quizzes}) {
    console.log(quizzes)
    state.quizzes = quizzes
    console.log(state.quizzes)

  },
  reset(state) {
    Object.assign(state, initState())
  }
}

export const actions = {
  async fetchQuizzes(context) {
    const quizzes = await this.$axios.$get('/api/quizzes')
    context.commit('setQuizzes', {quizzes})
  },
  async createQuiz(context, {quiz}) {
    await this.$axios.$post('/api/quizzes', quiz)
    await context.dispatch('fetchQuizzes')
  }
}
