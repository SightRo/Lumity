<template>
  <b-card bg-variant="light">
    <b-form-group label="Quiz creation" label-size="lg" class="mb-0" label-class="font-weight-bold pt-0">
      <b-form-group label-cols-sm="3" label="Name:" label-for="nested-name">
        <b-form-input id="nested-name" v-model="name"></b-form-input>
      </b-form-group>

      <b-form-group label-cols-sm="3" label="Description:" label-for="nested-description">
        <b-form-input id="nested-description" v-model="description"></b-form-input>
      </b-form-group>

      <b-form-group label="Questions" label-align="center">
        <b-form-group v-for="question in questions" :key="question.order" label-cols-sm="3"
                      :label="'Question #'+ question.order" label-for="nested-question">
          <b-form-input id="nested-question" v-model="question.text"></b-form-input>

          <b-form-radio-group v-model="question.rightOption">
            <div v-for="option in question.options" :key="option.order">
              <b-form-radio :value="option.order"></b-form-radio>
              <label>{{'Option #'+ option.order}}</label>
              <b-form-input v-model="option.text"></b-form-input>
            </div>
          </b-form-radio-group>

        </b-form-group>
        <b-button @click="addQuestion">Add question</b-button>
      </b-form-group>
      <b-button @click="createQuiz({quiz: {name, description, questions}})">Submit</b-button>
    </b-form-group>
  </b-card>
</template>

<script>
  import {mapActions} from 'vuex'

  //Todo Add reset on submit button
  export default {
    name: "input-quiz",

    data: () => ({
      name: '',
      description: '',
      questions: []
    }),

    methods: {
      ...mapActions('quizzes', ['createQuiz']),

      addQuestion() {
        const question = {
          order: this.questions.length + 1,
          text: '',
          rightOption: null,
          options: []
        }

        this.addOption(question);
        this.addOption(question);
        this.addOption(question);
        this.addOption(question);

        this.questions.push(question)
      },

      addOption(question) {
        const option = {
          order: question.options.length + 1,
          text: '',
        }
        question.options.push(option)
      }
    },

    fetch() {
      this.addQuestion()
    }
  }
</script>

<style scoped>
</style>
