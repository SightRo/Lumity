<template>
  <div class="container">
    <div>
      <div v-if="quizzes">
        <p v-for="quiz in quizzes" :key="quiz.id">
          {{quiz.id}} - {{quiz.name}}
        </p>
      </div>

      <div>
        <b-card class="container">
          <b-card-title class="text-center">Quiz name</b-card-title>
          <b-card-body class="row">
            <b-input type="text" v-model="quizName"/>
            <b-button @click="saveQuiz" class="col text-center mt-2">
              save
            </b-button>
          </b-card-body>
        </b-card>
      </div>
    </div>
  </div>
</template>

<script>
  import {mapMutations, mapActions, mapState} from 'vuex'

  export default {

    name: 'HomePage',

    data: () => ({
      quizName: ''
    }),

    computed: {
      ...mapState('quizzes', {
        quizzes: state => state.quizzes
      })
    },

    methods: {
      ...mapMutations('quizzes', ['reset', 'setQuizzes']),
      ...mapActions('quizzes', ['fetchQuizzes', 'createQuiz']),

      async saveQuiz() {
        await this.createQuiz({quiz: {name: this.quizName}});
        this.quizName = ''
      }
    }
  }
</script>

<style>
</style>
