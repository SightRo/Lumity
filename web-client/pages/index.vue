<template>
  <section class="section">
    <div>
      <div v-if="quizzes">
        <p v-for="quiz in quizzes" :key="quiz.id">
          {{quiz.id}} - {{quiz.name}}
        </p>
      </div>

      <div>
        <b-field label="Quiz name">
          <b-input v-model="quizName"/>
        </b-field>
        <b-button @click="saveQuiz">
          save
        </b-button>
      </div>
    </div>
  </section>
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
