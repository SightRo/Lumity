<template>
  <b-card :title="quiz.name">
    <b-card-body>
      <b-card-text>
        {{quiz.description}}
      </b-card-text>
      <b-card v-for="question in quiz.questions" :key="question.id">
        <b-card-body>
          <b-card-text>
            <h5>{{question.order}}. {{question.text}}</h5>
            <b-form-radio-group v-model="value" stacked :options="question.options">
            </b-form-radio-group>
          </b-card-text>
        </b-card-body>
      </b-card>
    </b-card-body>
  </b-card>
</template>

<script>
  export default {
    name: "quiz",

    data: () => ({
      value: null
    }),

    props: {
      quiz: {
        type: Object,
        required: true
      },
    },
  }
</script>

<style scoped>

</style>
