<template>
  <v-layout
    column
    justify-center
    align-center
  >
    <div>
      <div v-if="quizzes">
        <p v-for="quiz in quizzes" :key="quiz.id">
          {{quiz.id}} - {{quiz.name}}
        </p>
      </div>

      <div>
        <v-text-field label="Quiz name" v-model="quizName"/>
        <v-btn @click="saveQuiz">
          save
        </v-btn>
      </div>
    </div>
  </v-layout>
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
