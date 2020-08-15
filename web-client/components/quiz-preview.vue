<template>
  <b-card :title="quiz.name">
    <b-card-sub-title>
      {{quiz.questions.length}} questions
    </b-card-sub-title>

    <b-card-body >
      {{quiz.description}}
    </b-card-body>
  </b-card>
</template>

<script>
  export default {
    name: "quiz-preview",

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
