<template>
  <div class="container">
    <div>
      <div v-if="quizzes">
        <div v-for="quiz in quizzes" :key="quiz.id">
          <quiz :quiz="quiz"/>
        </div>
      </div>

      <div>
        <input-quiz/>
      </div>
    </div>
  </div>
</template>

<script>
  import {mapMutations, mapActions, mapState} from 'vuex'
  import quiz from "../components/quiz"
  import InputQuiz from "../components/input-quiz";

  export default {

    name: 'HomePage',

    components: {
      InputQuiz,
      quiz
    },

    data: () => ({
      quizName: ''
    }),

    computed: {
      ...mapState('quizzes', {
        quizzes: state => state.quizzes
      })
    },

    async fetch() {
      await this.$store.dispatch('quizzes/fetchQuizzes')
    }
  }
</script>

<style>
</style>
